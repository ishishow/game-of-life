package handler

import (
	"encoding/json"
	"lifegame/domain/model"
	"lifegame/presenter/dcontext"
	"lifegame/presenter/http/response"
	"lifegame/usecase"
	"log"
	"net/http"
	"strconv"
)

type LifeModelHandler struct {
	LifeModelUseCase usecase.LifeModelUseCase
}

func NewLifeModelHandler(lu usecase.LifeModelUseCase) LifeModelHandler {
	return LifeModelHandler{
		LifeModelUseCase: lu,
	}
}

func (lh LifeModelHandler) HandleCreate() http.HandlerFunc {
	return func(writer http.ResponseWriter, request *http.Request) {
		ctx := request.Context()
		userID := dcontext.GetUserIDFromContext(ctx)

		var requestBody createLifeModelRequest
		if err := json.NewDecoder(request.Body).Decode(&requestBody); err != nil {
			log.Println(err)
			response.BadRequest(writer, "Content-Type must be application/json")
			return
		}
		var strMap string
		for _, i := range requestBody.Map {
			strMap += strconv.Itoa(i)
		}

		lifeModel := &model.LifeModel{
			ID:   "",
			Name: requestBody.Name,
			Map:  strMap,
			User: &model.User{
				ID:        userID,
				Name:      "",
				AuthToken: "",
			},
			Favorite: 0,
		}

		if err := lh.LifeModelUseCase.Create(lifeModel); err != nil {
			log.Printf("%v", err)
			response.InternalServerError(writer, "error")
		}
		response.Success(writer, &createLifeModelResponse{})
	}
}

func (lh LifeModelHandler) HandleGet() http.HandlerFunc {
	return func(writer http.ResponseWriter, request *http.Request) {
		var requestBody getLifeModelRequest
		if err := json.NewDecoder(request.Body).Decode(&requestBody); err != nil {
			log.Println(err)
			response.BadRequest(writer, "Content-Type must be application/json")
			return
		}

		lifeModel, err := lh.LifeModelUseCase.Get(requestBody.ID)
		if err != nil {
			log.Printf("%v", err)
			response.InternalServerError(writer, "error")
		}

		response.Success(writer, &getLifeModelResponse{
			LifeModel: lifeModel,
		})
	}
}

func (lh LifeModelHandler) HandleRanking() http.HandlerFunc {
	return func(writer http.ResponseWriter, request *http.Request) {
		lifeModelList, err := lh.LifeModelUseCase.Ranking()
		if err != nil {
			log.Printf("%v", err)
			response.InternalServerError(writer, "error")
		}

		response.Success(writer, &rankingLifeModelResponse{
			LifeModelList: lifeModelList,
		})
	}
}

func (lh LifeModelHandler) HandleSetFavorite() http.HandlerFunc {
	return func(writer http.ResponseWriter, request *http.Request) {
		ctx := request.Context()
		userID := dcontext.GetUserIDFromContext(ctx)
		var requestBody setFavoriteRequest
		if err := json.NewDecoder(request.Body).Decode(&requestBody); err != nil {
			log.Println(err)
			response.BadRequest(writer, "Content-Type must be application/json")
			return
		}

		if err := lh.LifeModelUseCase.SetFavorite(requestBody.ID, userID); err != nil {
			log.Printf("%v", err)
			response.InternalServerError(writer, "error")
		}

		response.Success(writer, &setFavoriteResponse{})
	}
}

func (lh LifeModelHandler) HandleUserModels() http.HandlerFunc {
	return func(writer http.ResponseWriter, request *http.Request) {
		ctx := request.Context()
		userID := dcontext.GetUserIDFromContext(ctx)

		lifeModelList, err := lh.LifeModelUseCase.UserModels(userID)
		if err != nil {
			log.Printf("%v", err)
			response.InternalServerError(writer, "error")
		}

		response.Success(writer, &lifeModelList)
	}
}

type setFavoriteRequest struct {
	ID string `json:"id"`
}
type setFavoriteResponse struct{}

type createLifeModelRequest struct {
	UserID string `json:"user_id"`
	Name   string `json:"name"`
	Map    []int  `json:"map"`
}

type createLifeModelResponse struct{}

type getLifeModelRequest struct {
	ID string `json:"id"`
}

type getLifeModelResponse struct {
	LifeModel *model.LifeModel `json:"life_model"`
}

type rankingLifeModelRequest struct{}

type rankingLifeModelResponse struct {
	LifeModelList []*model.LifeModel `json:"life_model_list"`
}

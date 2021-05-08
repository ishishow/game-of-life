package usecase

import (
	"lifegame/domain/model"
	"lifegame/domain/repository"

	"github.com/google/uuid"
)

type LifeModelUseCase interface {
	Create(lifeModel *model.LifeModel) error
	Get(ID string) (*model.LifeModel, error)
	Ranking() ([]*model.LifeModel, error)
	SetFavorite(ID string, userID string) error
	UserModels(userID string) ([]*model.LifeModel, error)
}

type lifeModelUseCase struct {
	lifeModelRepository repository.LifeModelRepository
	userRepository      repository.UserRepository
}

func NewLifeModelUseCase(lifeModelRepo repository.LifeModelRepository,
	userRepo repository.UserRepository) LifeModelUseCase {
	return &lifeModelUseCase{
		lifeModelRepository: lifeModelRepo, userRepository: userRepo,
	}
}

func (lu *lifeModelUseCase) Create(lifeModel *model.LifeModel) error {
	ID, err := uuid.NewRandom()
	if err != nil {
		return err
	}
	lifeModel.ID = ID.String()
	return lu.lifeModelRepository.Create(lifeModel)
}

func (lu *lifeModelUseCase) Get(ID string) (*model.LifeModel, error) {
	lifeModel, err := lu.lifeModelRepository.Get(ID)
	if err != nil {
		return lifeModel, err
	}
	lifeModel.Favorite, err = lu.lifeModelRepository.GetFavoriteCount(ID)
	if err != nil {
		return lifeModel, err
	}
	return lu.fillUserDetails(lifeModel)
}

func (lu *lifeModelUseCase) SetFavorite(ID string, userID string) error {
	return lu.lifeModelRepository.SetFavorite(ID, userID)
}

func (lu *lifeModelUseCase) Ranking() ([]*model.LifeModel, error) {
	favorites, err := lu.lifeModelRepository.Ranking()
	if err != nil {
		return nil, err
	}
	lifeModels := []*model.LifeModel{}
	modelIDList := []string{}
	modelIDMap := make(map[string]bool)

	for _, favorite := range favorites {
		if !modelIDMap[favorite.ModelID] {
			modelIDMap[favorite.ModelID] = true
			modelIDList = append(modelIDList, favorite.ModelID)
		}
	}
	for _, modelID := range modelIDList {
		lifeModel, err := lu.Get(modelID)
		if err != nil {
			return lifeModels, err
		}
		lifeModel.Favorite, err = lu.lifeModelRepository.GetFavoriteCount(lifeModel.ID)
		if err != nil {
			return lifeModels, err
		}
		lifeModels = append(lifeModels, lifeModel)
	}
	for i := range lifeModels {
		for j := i; j < len(lifeModels); j++ {
			if lifeModels[i].Favorite > lifeModels[j].Favorite {
				break
			}
			tmp := lifeModels[i]
			lifeModels[i] = lifeModels[j]
			lifeModels[j] = tmp
		}
	}
	return lifeModels, nil
}

func (lu *lifeModelUseCase) UserModels(userID string) ([]*model.LifeModel, error) {
	lifeModels, err := lu.lifeModelRepository.UserModels(userID)
	if err != nil {
		return nil, err
	}

	for _, lifeModel := range lifeModels {
		lifeModel, err = lu.fillUserDetails(lifeModel)
		if err != nil {
			return nil, err
		}
		lifeModel.Favorite, err = lu.lifeModelRepository.GetFavoriteCount(lifeModel.ID)
		if err != nil {
			return lifeModels, err
		}
	}
	return lifeModels, nil
}

func (lu *lifeModelUseCase) fillUserDetails(lifeModel *model.LifeModel) (*model.LifeModel, error) {
	user, err := lu.userRepository.Get(lifeModel.User.ID)
	if err != nil {
		return nil, err
	}
	lifeModel.User = user
	return lifeModel, err
}

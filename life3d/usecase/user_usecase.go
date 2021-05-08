package usecase

import (
	"github.com/google/uuid"
	"lifegame/domain/model"
	"lifegame/domain/repository"
)

type UserUseCase interface {
	Create(name string) (user *model.User, err error)
	Get(authToken string) (*model.User, error)
	SelectByAuthToken(authToken string) (*model.User, error)
}

type userUseCase struct {
	repository repository.UserRepository
}

func NewUserUseCase(userRepo repository.UserRepository) UserUseCase {
	return &userUseCase{
		repository: userRepo,
	}
}
func (uu *userUseCase) Create(name string) (*model.User, error) {
	userID, err := uuid.NewRandom()
	if err != nil {
		return nil, err
	}
	token, err := uuid.NewRandom()
	if err != nil {
		return nil, err
	}

	return uu.repository.Create(userID.String(), token.String(), name)
}

func (uu *userUseCase) Get(userID string) (*model.User, error) {
	return uu.repository.Get(userID)
}

func (uu *userUseCase) SelectByAuthToken(authToken string) (*model.User, error) {
	return uu.repository.SelectByAuthToken(authToken)
}

package repository

import "lifegame/domain/model"

type UserRepository interface {
	Create(id string, token string, name string) (user *model.User, err error)
	Get(userID string) (user *model.User, err error)
	SelectByAuthToken(authToken string) (user *model.User, err error)
}

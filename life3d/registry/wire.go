// +build wireinject

package registry

import (
	"lifegame/infrastructure/persistence/postgre"
	"lifegame/presenter/http/handler"
	"lifegame/presenter/http/middleware"
	"lifegame/usecase"

	"github.com/google/wire"
)

func InitializeAuth() middleware.Middleware {
	wire.Build(
		postgre.NewSQLHandler,
		postgre.NewUserRepositoryImpl,
		usecase.NewUserUseCase,
		middleware.NewMiddleware,
	)
	return middleware.Middleware{}
}

func InitializeUserHandler() handler.UserHandler {

	wire.Build(
		usecase.NewUserUseCase,
		postgre.NewSQLHandler,
		handler.NewUserHandler,
		postgre.NewUserRepositoryImpl,
	)
	return handler.UserHandler{}
}

func InitializeLifeModelHandler() handler.LifeModelHandler {

	wire.Build(
		usecase.NewLifeModelUseCase,
		postgre.NewSQLHandler,
		handler.NewLifeModelHandler,
		postgre.NewLifeModelRepositoryImpl,
		postgre.NewUserRepositoryImpl,
	)
	return handler.LifeModelHandler{}
}

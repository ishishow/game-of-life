package middleware

import (
	"context"
	"lifegame/presenter/dcontext"
	"lifegame/presenter/http/response"
	"lifegame/usecase"
	"log"
	"net/http"
)

// Middleware ハンドラをラップしてx-tokenからuserIDをコンテキストに保存
type Middleware struct {
	userUseCase usecase.UserUseCase
}

// NewMiddleware userUseCaseと疎通
func NewMiddleware(uu usecase.UserUseCase) Middleware {
	return Middleware{
		userUseCase: uu,
	}
}

// Authenticate ユーザ認証を行ってContextへユーザID情報を保存する
func (m Middleware) Authenticate(nextFunc http.HandlerFunc) http.HandlerFunc {
	return func(writer http.ResponseWriter, request *http.Request) {
		ctx := request.Context()
		if ctx == nil {
			ctx = context.Background()
		}

		// リクエストヘッダからx-token(認証トークン)を取得
		token := request.Header.Get("x-token")
		if token == "" {
			log.Println("x-token is empty")
			return
		}

		user, err := m.userUseCase.SelectByAuthToken(token)
		if err != nil {
			log.Println(err)
			response.InternalServerError(writer, "Invalid token")
			return
		}
		if user == nil {
			log.Printf("user not found. token=%s", token)
			response.BadRequest(writer, "Invalid token")
			return
		}

		if user.ID == "" {
			log.Println("userID is empty")
			response.BadRequest(writer, "userID is empty")
			return
		}

		// ユーザIDをContextへ保存して以降の処理に利用する
		ctx = dcontext.SetUserID(ctx, user.ID)

		// 次の処理
		nextFunc(writer, request.WithContext(ctx))
	}
}

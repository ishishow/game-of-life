package server

import (
	"lifegame/registry"
	"log"
	"net/http"
)

// Serve HTTPサーバを起動する
func Serve(addr string) {

	uh := registry.InitializeUserHandler()
	lh := registry.InitializeLifeModelHandler()
	auth := registry.InitializeAuth()

	http.HandleFunc("/user/create", post(uh.HandleCreate()))
	http.HandleFunc("/user/get", get(auth.Authenticate(uh.HandleGet())))
	http.HandleFunc("/model/create", post(auth.Authenticate(lh.HandleCreate())))
	http.HandleFunc("/model/get", get(auth.Authenticate(lh.HandleGet())))
	http.HandleFunc("/model/ranking", get(auth.Authenticate(lh.HandleRanking())))
	http.HandleFunc("/model/favorite", post(auth.Authenticate(lh.HandleSetFavorite())))
	http.HandleFunc("/model/users", get(auth.Authenticate(lh.HandleUserModels())))

	/* ===== サーバの起動 ===== */
	log.Println("Server running...")
	err := http.ListenAndServe(addr, nil)
	if err != nil {
		log.Fatalf("Listen and serve failed. %+v", err)
	}
}

// get GETリクエストを処理する
func get(apiFunc http.HandlerFunc) http.HandlerFunc {
	return httpMethod(apiFunc, http.MethodGet)
}

// post POSTリクエストを処理する
func post(apiFunc http.HandlerFunc) http.HandlerFunc {
	return httpMethod(apiFunc, http.MethodPost)
}

// post POSTリクエストを処理する
func put(apiFunc http.HandlerFunc) http.HandlerFunc {
	return httpMethod(apiFunc, http.MethodPut)
}

// httpMethod 指定したHTTPメソッドでAPIの処理を実行する
func httpMethod(apiFunc http.HandlerFunc, method string) http.HandlerFunc {
	return func(writer http.ResponseWriter, request *http.Request) {

		// CORS対応
		writer.Header().Add("Access-Control-Allow-Origin", "*")
		writer.Header().Add("Access-Control-Allow-Headers", "Content-Type,Accept,Origin,x-token")
		writer.Header().Set("Access-Control-Allow-Headers", "*")
		writer.Header().Set("Access-Control-Allow-Origin", "*")
		writer.Header().Set("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS")

		// // // プリフライトリクエストは処理を通さない
		if request.Method == http.MethodOptions {
			writer.WriteHeader(http.StatusOK)
			return
		}
		// 指定のHTTPメソッドでない場合はエラー
		if request.Method != method {
			writer.WriteHeader(http.StatusMethodNotAllowed)
			writer.Write([]byte("Method Not Allowed"))
			return
		}
		// 共通のレスポンスヘッダを設定
		writer.Header().Add("Content-Type", "application/json")
		apiFunc(writer, request)
	}
}

# LIFEGAME3D

## 使用技術
- unity
- React　⇨ https://logmi.jp/tech/articles/323164
- golang
- heroku
- postgres

## ユースケース

- ライフゲームのルールを変更できる
- コマ送り、一時停止などができる
- 他のユーザーの作成したモデルをみれる
- 他のユーザーのモデルをお気に入り登録できる
- ユーザーがモデルを登録できる
- ユーザーが実際に試行できる
- ユーザーが名前を登録する
- ユーザーを登録できる
- お気に入り順にモデルが見れる
- (ユーザーが自分で登録したモデルを見れるようにする)

## API仕様
- [openAPI使用](https://github.com/ishishow/life3d/blob/master/open_api/api.document.yaml)


- user/create  POST ユーザー登録
- user/get  GET ユーザーネーム取得
- model/users  GET ユーザーが登録したモデル一覧
- model/ranking GET モデルお気に入り順
- model/create POST モデル登録
- model/get GET 他のモデル情報を返す
- model/favorite GET 他のモデル情報を返す

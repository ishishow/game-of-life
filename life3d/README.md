# LIFEGAME3D

## 使用技術
- unity
- React　⇨ https://logmi.jp/tech/articles/323164
- golang
- heroku →　https://lifegame-3d.herokuapp.com
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

```shell
curl -X 'POST' 'https://lifegame-3d.herokuapp.com/user/create' -H 'accept: application/json' -H 'Content-Type: application/json' -d '{"name": "ishishow-test03"}'
curl -X 'GET'       'https://lifegame-3d.herokuapp.com/user/get'       -H 'accept: application/json'       -H 'x-token: 1205a65f-7898-4686-be75-edef2a430ead'
curl -X 'POST'       'https://lifegame-3d.herokuapp.com/model/create'       -H 'accept: application/json'       -H 'x-token: 1205a65f-7898-4686-be75-edef2a430ead'     -d '{"user_id": "a62127d1-1ef3-443d-95b8-6eee7673728c", "name": "graider", "map": [1,1,1,1,0,0,0,2]}'
curl -X 'GET'       'https://lifegame-3d.herokuapp.com/model/get'       -H 'accept: application/json'       -H 'x-token: 1205a65f-7898-4686-be75-edef2a430ead'     -d '{"id": "0c652fa5-002b-49cc-81c7-754d922a13ca"}'
curl -X 'POST'       'https://lifegame-3d.herokuapp.com/model/favorite'       -H 'accept: application/json'       -H 'x-token: 1205a65f-7898-4686-be75-edef2a430ead'     -d '{"id": "0c652fa5-002b-49cc-81c7-754d922a13ca"}'
curl -X 'GET'       'https://lifegame-3d.herokuapp.com/model/ranking'       -H 'accept: application/json'       -H 'x-token: 1205a65f-7898-4686-be75-edef2a430ead'      | jq .
curl -X 'GET'   'https://lifegame-3d.herokuapp.com/model/users'   -H 'accept: application/json'   -H 'x-token: 1205a65f-7898-4686-be75-edef2a430ead'
```


```
post user/create
request{
name: “hogehoge”
}
response{
token: “uuidiuuuuuuu”
}
get user/models
request {
modelList:  
[
model: {id: “1”, name: “マップ１”, userName: “foo” favorite: 3},
model: {id: “11”, name: “マップ2”, userName: “foo”favorite: 0},
model: {id; “13”, name: “マップ3”, userName: “foo”favorite: 13},
model: {id: “30”, name: “マップ4”, userName: “foo”favorite: 34},
model: {id: “60”,name: “マップ5”, userName: “foo”favorite: 89},
]
}
get model/ranking {
request {}
response {
modelList:  
[
model: {id: “1”, name: “マップ１”,map: [[0,0,0,1],[0,0,1, 0],[0,0,2,1]........[49,49,49,1]]
,userName: “foo” favorite: 3},
model: {id: “11”, name: “マップ2”, map: [[0,0,0,1],[0,0,1, 0],[0,0,2,1]........[49,49,49,1]],
userName: “bo”favorite: 0},
model: {id; “13”, name: “マップ3”, map: [[0,0,0,1],[0,0,1, 0],[0,0,2,1]........[49,49,49,1]]
userName: “fo”favorite: 13},
model: {id: “100”, name: “マップ4”,map: [[0,0,0,1],[0,0,1, 0],[0,0,2,1]........[49,49,49,1]]
userName: “o”favorite: 34},
model: {id: “1000”,name: “マップ5”, map: [[0,0,0,1],[0,0,1, 0],[0,0,2,1]........[49,49,49,1]]
userName: “f”,favorite: 89},
]
}
}
}

post: model/create
request {
user_id: “1”,
map: map: [[0,0,0,1],[0,0,1, 0],[0,0,2,1]........[49,49,49,1]],
}

model/get
request {
id: “23”,
}
response {
user: “name~~~”,
map: [[0,0,0,1],[0,0,1, 0],[0,0,2,1]........[49,49,49,1]]
}


ドメインモデル
model {
id: string,
user_id: string,
name: string,
map: []int
favorite: int
}

user {
id: string,
authToken: string,
name: string,
}







永続化情報(DB)
model {
id: string,
user_id: string,
name: string,
map: text,
}

user {
id: string,
name: string
}

user_favorite{
user_id: string,
model_id: string,
(一意)
}

CREATE TABLE IF NOT EXISTS users (
"id" VARCHAR(128) NOT NULL ,
"auth_token" VARCHAR(128) NOT NULL,
"name" VARCHAR(64) NOT NULL,
PRIMARY KEY("id")
);

CREATE TABLE IF NOT EXISTS life_models (
"id" VARCHAR(128) NOT NULL ,
"user_id" VARCHAR(128) NOT NULL,
"name" VARCHAR(64) NOT NULL,
"life_map" TEXT NOT NULL,
PRIMARY KEY("id")
);

CREATE TABLE IF NOT EXISTS favorites (
"user_id" VARCHAR(128) NOT NULL,
"life_model_id" VARCHAR(128) NOT NULL,
UNIQUE ("user_id", "life_model_id")
);

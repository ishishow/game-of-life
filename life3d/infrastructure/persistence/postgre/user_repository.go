package postgre

import (
	"database/sql"
	"lifegame/domain/model"
	"lifegame/domain/repository"
	"log"
)

type userRepositoryImpl struct {
	SQLHandler
}

func NewUserRepositoryImpl(sqlHandler SQLHandler) repository.UserRepository {
	return &userRepositoryImpl{
		SQLHandler: sqlHandler,
	}
}

func (uri *userRepositoryImpl) Create(id string, token string, name string) (*model.User, error) {
	user := &model.User{
		ID:        id,
		AuthToken: token,
		Name:      name,
	}

	stmt, err := uri.SQLHandler.Conn.Prepare("INSERT INTO users(id, auth_token, name) VALUES ($1, $2, $3);")
	if err != nil {
		log.Println(err)
		return user, err
	}
	_, err = stmt.Exec(user.ID, user.AuthToken, user.Name)
	return user, err
}

func (uri *userRepositoryImpl) Get(userID string) (*model.User, error) {
	row := uri.SQLHandler.Conn.QueryRow("SELECT * FROM users WHERE id = $1", userID)
	return convertToUser(row)
}

func (uri *userRepositoryImpl) SelectByAuthToken(authToken string) (*model.User, error) {
	row := uri.SQLHandler.Conn.QueryRow("SELECT * FROM users WHERE auth_token = $1", authToken)
	return convertToUser(row)
}

// convertToUser rowデータをUserデータへ変換する
func convertToUser(row *sql.Row) (*model.User, error) {
	user := model.User{}
	if err := row.Scan(&user.ID, &user.AuthToken, &user.Name); err != nil {
		if err == sql.ErrNoRows {
			return nil, nil
		}
		return nil, err
	}
	return &user, nil
}

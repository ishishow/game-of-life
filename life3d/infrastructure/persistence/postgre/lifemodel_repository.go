package postgre

import (
	"database/sql"
	"lifegame/domain/model"
	"lifegame/domain/repository"
)

type lifeModelRepositoryImpl struct {
	SQLHandler
}

func NewLifeModelRepositoryImpl(sqlHandler SQLHandler) repository.LifeModelRepository {
	return &lifeModelRepositoryImpl{
		SQLHandler: sqlHandler,
	}
}

func (lri *lifeModelRepositoryImpl) Create(lifeModel *model.LifeModel) error {
	stmt, err := lri.SQLHandler.Conn.Prepare("INSERT INTO life_models(id, user_id, name, life_map) VALUES ($1, $2, $3, $4);")
	if err != nil {
		return err
	}
	_, err = stmt.Exec(lifeModel.ID, lifeModel.User.ID, lifeModel.Name, lifeModel.Map)
	return err
}

func (lri *lifeModelRepositoryImpl) Get(ID string) (*model.LifeModel, error) {
	row := lri.SQLHandler.Conn.QueryRow("SELECT * FROM life_models WHERE id = $1", ID)
	return convertToLifeModel(row)
}

func (lri *lifeModelRepositoryImpl) SetFavorite(ID string, userID string) error {
	stmt, err := lri.SQLHandler.Conn.Prepare("INSERT INTO favorites(user_id, life_model_id) VALUES ($1, $2);")
	if err != nil {
		return err
	}
	_, err = stmt.Exec(userID, ID)
	return err
}

func (lri *lifeModelRepositoryImpl) GetFavoriteCount(lifeModelID string) (count int, err error) {
	row := lri.SQLHandler.Conn.QueryRow("SELECT COUNT(*) FROM favorites WHERE life_model_id = $1", lifeModelID)
	err = row.Scan(&count)
	return count, err
}

func (lri *lifeModelRepositoryImpl) Ranking() ([]*model.Favorite, error) {
	rows, err := lri.SQLHandler.Conn.Query("SELECT * FROM favorites")
	if err != nil {
		return nil, err
	}
	return convertToLifeModels(rows)
}

func (lri *lifeModelRepositoryImpl) UserModels(userID string) ([]*model.LifeModel, error) {
	rows, err := lri.SQLHandler.Conn.Query("SELECT * FROM life_models WHERE user_id = $1", userID)
	if err != nil {
		return nil, err
	}
	return convertToLifeModelList(rows)
}

// convertToLifeModel rowデータをUserデータへ変換する
func convertToLifeModel(row *sql.Row) (*model.LifeModel, error) {
	lifeModel := model.LifeModel{}
	var userID string
	if err := row.Scan(&lifeModel.ID, &userID, &lifeModel.Name, &lifeModel.Map); err != nil {
		if err == sql.ErrNoRows {
			return nil, nil
		}
		return nil, err
	}
	lifeModel.User = &model.User{
		ID:        userID,
		AuthToken: "",
		Name:      "",
	}
	return &lifeModel, nil
}

func convertToLifeModelList(rows *sql.Rows) ([]*model.LifeModel, error) {
	lifeModels := []*model.LifeModel{}
	var userID string

	for rows.Next() {
		lifeModel := model.LifeModel{}
		if err := rows.Scan(&lifeModel.ID, &userID, &lifeModel.Name, &lifeModel.Map); err != nil {
			return nil, err
		}
		lifeModel.User = &model.User{
			ID:        userID,
			AuthToken: "",
			Name:      "",
		}
		lifeModels = append(lifeModels, &lifeModel)
	}
	return lifeModels, nil
}

func convertToLifeModels(rows *sql.Rows) ([]*model.Favorite, error) {
	favorites := []*model.Favorite{}

	for rows.Next() {
		favorite := model.Favorite{}
		if err := rows.Scan(&favorite.UserID, &favorite.ModelID); err != nil {
			return nil, err
		}
		favorites = append(favorites, &favorite)
	}
	return favorites, nil
}

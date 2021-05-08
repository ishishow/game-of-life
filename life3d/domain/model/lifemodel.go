package model

type LifeModel struct {
	ID       string `json:"id"`
	User     *User  `json:"user"`
	Name     string `json:"name"`
	Map      string `json:"map"`
	Favorite int    `json:"favorite"`
}

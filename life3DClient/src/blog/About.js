import Grid from "@material-ui/core/Grid";
import Paper from "@material-ui/core/Paper";
import { Typography } from "@material-ui/core";
import image3 from "../image3.gif";
import SportsEsportsRoundedIcon from "@material-ui/icons/SportsEsportsRounded";
import Link from "@material-ui/core/Link";
import Button from "@material-ui/core/Button";

function About() {
  return (
    <Grid>
      <Paper
        variant="rounded"
        elevation={7}
        square
        style={{ borderRadius: "5% / 5%" }}
      >
        <div style={{ margin: "3%", textAlign: "left" }}>
          <Typography
            component="h1"
            variant="h4"
            color="inherit"
            style={{ padding: "2% 3%", paddingTop: "4%" }}
          >
            {/* ライフゲームとは */}
            <strong>ライフゲームとは</strong>
          </Typography>
          <Typography
            component="h1"
            variant="h5"
            color="inherit"
            style={{ padding: "2% 3%" }}
          >
            ライフゲームは数学者コンウェイが考案した、
            <br />
            生命の誕生、進化、淘汰をモデルで再現したシミュレーションゲーム。
            <br />
            <br />
            単純なルールからなる模様の変化、パズル要素を楽しむことができる。
          </Typography>
          <Grid style={{ textAlign: "left" }}>
            <Typography
              component="h1"
              variant="h5"
              color="inherit"
              style={{ padding: "2% 3%", paddingTop: "3%" }}
            >
              <strong>基本ルール</strong>
            </Typography>
            <Typography style={{ padding: "0% 3%", paddingTop: "3%" }}>
              碁盤状の格子を作成し、その各セル(格子)を一つの生命とみなす。
              <br />
              この生命が次の世代に進むことでどのように変化していくのか、これを以下のルールでシミュレートする。
              <br />
              ライフゲームは現在の状態から次の世代の状態が決定する。
              <br />
              生命は生きている状態か死んでいる状態かのいずれかである。
              <br />
              <br />
              <strong>誕生</strong>
              <br />
              ある生命が死んでいる場合、周囲８セルの内周囲８セルの内ちょうど３つのセルが生きていれば次の世代で新しい生命が誕生する。
              <br />
              <br />
              <strong>生存</strong>
              <br />
              ある生命が生きている場合、周囲８セルの内２セルあるいは３セルが生きている場合、次の世代でも生存する。
              <br />
              <br />
              <strong>過疎</strong>
              <br />
              ある生命が生きている場合、周囲８セルの内生きているセルが１セル以下の場合、次の世代では過疎で死滅する。
              <br />
              <br />
              <strong>過密</strong>
              <br />
              ある生命が生きている場合、周囲８セルの内生きているセルが4セル以上の場合、次の世代では過密で死滅する。
              <br />
            </Typography>
            <Typography
              component="h1"
              variant="h5"
              color="inherit"
              style={{ padding: "2% 3%", paddingTop: "3%" }}
            >
              <strong>本ゲームの特徴</strong>
            </Typography>
            <Typography style={{ padding: "0% 3%", paddingTop: "3%" }}>
              インターネット上で<strong>「ライフゲーム」</strong>
              と検索するとほぼ２次元で施工されているがUnityを駆使して３次元で表した。
              <br />
              二次元時と比べ、三次元だと厚みが出るのでより多くの生命パターンが発見できるだろう。
              <br />
              <br />
              <img src={image3} alt="" width="300" />
            </Typography>
            <Typography
              style={{
                padding: "5% 5%",
                paddingTop: "8%",
                textAlign: "center",
              }}
            >
              <Link variant="subtitle1" href="#/game">
                <Button
                  variant="contained"
                  color="primary"
                  size="large"
                  startIcon={<SportsEsportsRoundedIcon />}
                  style={{ borderRadius: 50, color: "#ffffff" }}
                >
                  Play Now !!
                </Button>
              </Link>
            </Typography>
          </Grid>
        </div>
      </Paper>
    </Grid>
  );
}

export default About;

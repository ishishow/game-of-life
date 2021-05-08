import Grid from "@material-ui/core/Grid";
import Paper from "@material-ui/core/Paper";
import { Typography } from "@material-ui/core";
import image3 from "../image3.gif";
import SportsEsportsRoundedIcon from "@material-ui/icons/SportsEsportsRounded";
import Link from "@material-ui/core/Link";
import Button from "@material-ui/core/Button";

function Tech() {
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
            <strong>使用技術</strong>
          </Typography>
          <Typography style={{ padding: "0% 3%", paddingTop: "3%" }}>
            <br />
            <strong>Unity</strong> : ver2019
            <br />
            <br />
            <strong>Golang</strong>
            : ver1.6
            <br />
            <br />
            <strong>JavaScript(React)</strong>
            : react--unity-webgl
            <br />
            <br />
            <strong>Postgres</strong>
            : heroku無料枠
            <br />
            <br />
            <strong>Heroku</strong>
            : 無料枠使用(Go, Postgres)
            <br />
          </Typography>
          <Grid style={{ textAlign: "left" }}>
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

export default Tech;

import React from "react";
import { HashRouter, Route, Switch } from "react-router-dom";
import { makeStyles } from "@material-ui/core/styles";
import CssBaseline from "@material-ui/core/CssBaseline";
import Container from "@material-ui/core/Container";
import About from "./About";
import Game from "./Game";
import Tech from "./Tech";
import MainFeaturedPost from "./MainFeaturedPost";

const useStyles = makeStyles((theme) => ({
  mainGrid: {
    marginTop: theme.spacing(3),
  },
}));

const sections = [
  { title: "Top", url: "#/top" },
  { title: "About", url: "#/about" },
  { title: "Game", url: "#/game" },
  { title: "Technology", url: "#/tech" },
];

const mainFeaturedPost = {
  title: "LifeGame 3D Top Page",
  description:
    "ライフゲームとは生命の誕生、進化、淘汰などのプロセスを再現したモデルであり、こちらでは３Dバージョンが楽しめます。",
  image:
    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTbihgOPtSQt7T3Rro-H9T-YcIb1S8jxR43dYVmIcTrfTxkpL1Dc2NJ29U7VhMhhN5u4Nk&usqp=CAU",
  imgText: "main image description",
  linkText: "Wikipedia link...",
};

export default function Blog() {
  const classes = useStyles();

  return (
    <HashRouter>
      <React.Fragment>
        <CssBaseline />
        <Container maxWidth="lg">
          <main>
            <Switch>
              <Route exact path="/top">
                <MainFeaturedPost post={mainFeaturedPost} />
              </Route>
              <Route exact path="/about">
                <About />
              </Route>
              <Route path="/game">
                <Game />
              </Route>
              <Route path="/tech">
                <Tech />
              </Route>
              <Route>
                <MainFeaturedPost post={mainFeaturedPost} />
              </Route>
            </Switch>
          </main>
        </Container>
      </React.Fragment>
    </HashRouter>
  );
}

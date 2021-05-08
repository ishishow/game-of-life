import React from "react";
import PropTypes from "prop-types";
import { makeStyles } from "@material-ui/core/styles";
import Typography from "@material-ui/core/Typography";
import Grid from "@material-ui/core/Grid";
import Link from "@material-ui/core/Link";
import Logo from "../logo5.png";
import { Button } from "@material-ui/core";
import SearchIcon from "@material-ui/icons/Search";
import SportsEsportsRoundedIcon from "@material-ui/icons/SportsEsportsRounded";
const useStyles = makeStyles((theme) => ({
  mainFeaturedPost: {
    position: "relative",
    backgroundColor: theme.palette.grey[800],
    color: theme.palette.common.white,
    marginBottom: theme.spacing(4),
    backgroundImage: "url(https://source.unsplash.com/random)",
    backgroundSize: "cover",
    backgroundRepeat: "no-repeat",
    backgroundPosition: "center",
  },
  overlay: {
    position: "absolute",
    top: 0,
    bottom: 0,
    right: 0,
    left: 0,
    backgroundColor: "rgba(0,0,0,.3)",
  },
  mainFeaturedPostContent: {
    position: "relative",
    padding: theme.spacing(3),
    [theme.breakpoints.up("md")]: {
      padding: theme.spacing(6),
      paddingRight: 0,
    },
  },
}));

export default function MainFeaturedPost(props) {
  const classes = useStyles();
  const { post } = props;

  return (
    <Grid container>
      <Grid item md={7}>
        <div className={classes.mainFeaturedPostContent}>
          <Typography component="h1" variant="h3" color="inherit" gutterBottom>
            <img src={Logo} alt="" width="280" />
          </Typography>
          <Typography variant="h4" color="inherit" paragraph>
            <strong>
              ライフゲームとは生命の誕生、進化、淘汰などのプロセスを再現したモデルであり、
              <br />
              こちらでは３Dバージョンが楽しめます。
              <br />　
            </strong>
          </Typography>
          <Grid container>
            <Grid item md={6} xs={12}>
              <Link
                variant="subtitle1"
                href="https://ja.wikipedia.org/wiki/%E3%83%A9%E3%82%A4%E3%83%95%E3%82%B2%E3%83%BC%E3%83%A0#:~:text=%E3%83%A9%E3%82%A4%E3%83%95%E3%82%B2%E3%83%BC%E3%83%A0%20(Conway's%20Game%20of,%E3%81%97%E3%81%9F%E3%82%B7%E3%83%9F%E3%83%A5%E3%83%AC%E3%83%BC%E3%82%B7%E3%83%A7%E3%83%B3%E3%82%B2%E3%83%BC%E3%83%A0%E3%81%A7%E3%81%82%E3%82%8B%E3%80%82"
              >
                <Button
                  variant="contained"
                  color="inherit"
                  startIcon={<SearchIcon />}
                  style={{ borderRadius: 50, color: "#000000" }}
                >
                  {post.linkText}
                </Button>
              </Link>
            </Grid>
            <Grid item md={6} xs={12}>
              <Link variant="subtitle1" href="#/game">
                <Button
                  variant="contained"
                  color="inherit"
                  startIcon={<SportsEsportsRoundedIcon />}
                  style={{ borderRadius: 50, color: "#000000" }}
                >
                  Play Now !!
                </Button>
              </Link>
            </Grid>
          </Grid>
        </div>
      </Grid>
    </Grid>
  );
}

MainFeaturedPost.propTypes = {
  post: PropTypes.object,
};

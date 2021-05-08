import React from "react";
import PropTypes from "prop-types";
import { makeStyles } from "@material-ui/core/styles";
import Typography from "@material-ui/core/Typography";
import Grid from "@material-ui/core/Grid";
import Link from "@material-ui/core/Link";
import { Button } from "@material-ui/core";

const useStyles = makeStyles({
  card: {
    display: "flex",
  },
  cardDetails: {
    flex: 1,
  },
  cardMedia: {
    width: 160,
  },
});

export default function FeaturedPost(props) {
  const classes = useStyles();
  const { post } = props;

  return (
    <Grid item xs={12} md={6}>
      <div className={classes.cardDetails}>
        <Typography component="h2" variant="h4">
          {post.title}
        </Typography>
        <Typography variant="subtitle1" color="textSecondary">
          {post.date}
        </Typography>
        <Typography variant="subtitle1" paragraph>
          {post.description}
        </Typography>
        <Typography variant="subtitle1" color="primary">
          <Link color="inherit" noWrap variant="body2" href={post.url}>
            <Button
              variant="contained"
              color="#ffffff"
              style={{ borderRadius: 50, color: "#000000" }}
            >
              {post.linkText}
            </Button>
          </Link>
        </Typography>
      </div>
    </Grid>
  );
}

FeaturedPost.propTypes = {
  post: PropTypes.object,
};

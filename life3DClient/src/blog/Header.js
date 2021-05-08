import React from "react";
import PropTypes from "prop-types";
import { makeStyles } from "@material-ui/core/styles";
import Toolbar from "@material-ui/core/Toolbar";
import Link from "@material-ui/core/Link";
import Logo from "../logo.png";

const useStyles = makeStyles((theme) => ({
  toolbar: {
    borderBottom: `1x solid ${theme.palette.divider}`,
  },
  toolbarSecondary: {
    display: "flex",
    overflowX: "auto",
  },
  toolbarLink: {
    marginTop: "5px",
    margin: theme.spacing(1),
    flexShrink: 0,
  },
  sss: {
    marginRight: "auto",
    marginTop: "5px",
    marginLeft: "15px",
  },
}));

export default function Header(props) {
  const classes = useStyles();
  const { sections, title } = props;

  return (
    <React.Fragment>
      <Toolbar
        component="nav"
        variant="dense"
        className={classes.toolbarSecondary}
      >
        <div className={classes.sss}>
          <img src={Logo} alt="" width="170" />
        </div>
        {sections.map((section) => (
          <Link
            color="inherit"
            noWrap
            key={section.title}
            variant="body1"
            href={section.url}
            className={classes.toolbarLink}
            style={{ marginRight: "3vw" }}
          >
            <strong>{section.title}</strong>
          </Link>
        ))}
      </Toolbar>
    </React.Fragment>
  );
}

Header.propTypes = {
  sections: PropTypes.array,
  title: PropTypes.string,
};

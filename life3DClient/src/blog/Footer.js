// import React from "react";
// import Typography from "@material-ui/core/Typography";
// import { makeStyles } from "@material-ui/core/styles";
// import Link from "@material-ui/core/Link";
// import Sidebar from "./Sidebar";
// import GitHubIcon from "@material-ui/icons/GitHub";
// import TwitterIcon from "@material-ui/icons/Twitter";

// function Copyright() {
//   return (
//     <Typography variant="body2" color="textSecondary">
//       {"Copyright © "}
//       <Link color="inherit" href="https://material-ui.com/">
//         Your Website
//       </Link>{" "}
//       {new Date().getFullYear()}
//       {"."}
//     </Typography>
//   );
// }

// const useStyles = makeStyles((theme) => ({
//   footer: {
//     backgroundColor: theme.palette.background.paper,
//     marginTop: theme.spacing(6),
//     padding: theme.spacing(4),
//   },
// }));

// export default function Footer() {
//   const classes = useStyles();
//   const sidebar = {
//     title: "About",
//     description:
//       "Etiam porta sem malesuada magna mollis euismod. Cras mattis consectetur purus sit amet fermentum. Aenean lacinia bibendum nulla sed consectetur.",
//     archives: [
//       { title: "March 2020", url: "#" },
//       { title: "February 2020", url: "#" },
//       { title: "January 2020", url: "#" },
//       { title: "November 1999", url: "#" },
//       { title: "October 1999", url: "#" },
//       { title: "September 1999", url: "#" },
//       { title: "August 1999", url: "#" },
//       { title: "July 1999", url: "#" },
//       { title: "June 1999", url: "#" },
//       { title: "May 1999", url: "#" },
//       { title: "April 1999", url: "#" },
//     ],
//     social: [
//       { name: "GitHub", icon: GitHubIcon, url: "https://github.com/ishishow" },
//       { name: "Twitter", icon: TwitterIcon, url: "https://twitter.com/home" },
//     ],
//   };

//   return (
//     <footer className={classes.footer}>
//       <Typography
//         variant="subtitle1"
//         align="center"
//         color="textSecondary"
//         component="p"
//       >
//         <Sidebar
//           title={sidebar.title}
//           description={sidebar.description}
//           archives={sidebar.archives}
//           social={sidebar.social}
//         />
//       </Typography>
//       <Copyright />
//     </footer>
//   );
// }

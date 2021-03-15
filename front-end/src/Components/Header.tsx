import { Container, AppBar, Toolbar, IconButton, Typography, Button, Slide, useScrollTrigger, makeStyles } from "@material-ui/core";
import { LocalHospital } from "@material-ui/icons";
import React, { Fragment } from "react";

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1
  },
}));
interface Props {
  /**
   * Injected by the documentation to work in an iframe.
   * You won't need it on your project.
   */
  window?: () => Window;
  children: React.ReactElement;
}

const Header = () => {
  const classes = useStyles();
  return (
    <div className={classes.root}>
      <AppBar position="relative">
        <Toolbar>
          <IconButton edge="start" aria-label="Home" >
            <LocalHospital htmlColor="white" />
          </IconButton>
          <Typography variant="h6">Doctor.Ly</Typography>
        </Toolbar>
      </AppBar>
    </div>
  );
}

export default Header;
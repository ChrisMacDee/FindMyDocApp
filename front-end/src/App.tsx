import './App.css';
import { useState } from 'react';
import { Box } from '@material-ui/core';
import Header from './Components/Header';
import Map from './Components/Map';

const App = () => {
  return (<Box className="App">
    <Header />
    <Box>
      <Map />
    </Box>
  </Box>);
}

export default App;

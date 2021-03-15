import { Card, makeStyles } from '@material-ui/core';
import { AssignmentInd } from '@material-ui/icons';
import InfoWindow from './InfoWindow';

const useStyles = makeStyles({
  marker: {   
  },
  "&:hover": {
    zIndex: 1,
    cursor: 'pointer'
  },
  container: {
    pointerEvents: 'none'
  }
});

const DocMarker = (props: any) => {
  const { color, name, id, doctor, show } = props;
  const styles = useStyles();
  const infoWindow = new google.maps.InfoWindow({
    content: ""
  });

  return (

      <AssignmentInd fontSize="large" color="primary" className={styles.marker}/>

  );
};

export default DocMarker;
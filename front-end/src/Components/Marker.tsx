import { makeStyles } from '@material-ui/core';
import { Room } from '@material-ui/icons';

const useStyles = makeStyles({
    marker : {
        position: "absolute",
        top: "50%",
        left: "50%",
        width: "18px",
        height: "18px",
        backgroundColor: "#000",
        border: "2px solid z\"#fff\"",
        borderRadius: "100%",
        userSelect: "none",
        transform: "translate(-50%, -50%)",        
    },
    "&:hover" : {
        zIndex: 1
      }
});

const Marker = (props : any) => {
    const { color, name, id} = props;
    return (
      <Room fontSize="large" color="secondary"/>
    );
  };

  export default Marker;
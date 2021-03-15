import { Button, Dialog, DialogTitle, DialogContent, DialogContentText, TextField, DialogActions, Typography, Grid, Avatar, makeStyles, createStyles, Theme, Box, List, ListItem, ListItemText, ListItemIcon } from "@material-ui/core";
import React, { useState } from "react";
import InfoIcon from '@material-ui/icons/Info';
const useStyles = makeStyles((theme: Theme) =>
    createStyles({
        large: {
            width: theme.spacing(7),
            height: theme.spacing(7),
        },
    }),
);
interface BookingPostModel {
    applicantFullName: string;
    applicantEmailAddress: string;
    nhsNumber: string;
    dateTimeOfBooking: Date;
    doctorFullName: string,
    doctorAddress: string,
    placeId: string
}
const BookingFormDialog = (props: any) => {
    const { open, handleClose, doctor } = props;
    const classes = useStyles();
    const [fullName, setName] = useState("");
    const [email, setEmail] = useState("");
    const [bookingDate, setBookingDate] = useState(new Date());
    const [nhsNumber, setNHSNumber] = useState("");
    const [bookingComplete, setBookingComplete] = useState(false);

    const onChangeName = (e: any) => {
        setName(e.target.value)
    }
    const onChangeEmail = (e: any) => {
        setEmail(e.target.value)
    }
    const onChangeNHSNumber = (e: any) => {
        setNHSNumber(e.target.value)
    }
    const onChangeDate = (e: any) => {
        setBookingDate(e.target.value)
    }
    const handleSubmit = (event: any) => {
        var postModel: BookingPostModel = {
            applicantEmailAddress: email,
            applicantFullName: fullName,
            nhsNumber: nhsNumber,
            dateTimeOfBooking: bookingDate,
            doctorFullName: doctor?.name,
            doctorAddress: doctor?.address,
            placeId: doctor?.place_id
        }
        console.log(postModel);
        fetch('https://localhost:44308/bookings', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            // We convert the React state to JSON and send it as the POST body
            body: JSON.stringify(postModel)
        }).then(function (response) {
            setBookingComplete(true);
        });
    }
    return (
        <div>
            <Dialog open={open} onClose={handleClose} aria-labelledby="form-dialog-title" maxWidth="lg">
                <DialogTitle id="form-dialog-title">Book an appointment</DialogTitle>
                <DialogContent>
                    {
                        bookingComplete && (
                            <Grid container spacing={2}>
                                <Grid item md={12} xs={12}>
                                    <Typography variant="h4" gutterBottom>Appointment booked</Typography>
                                    <Typography gutterBottom>Thanks, you've made a booking with...</Typography>
                                    <Grid container alignItems="center">
                                        <Grid item xs={2}><Avatar alt={doctor?.fullName} src="https://www.fillmurray.com/300/350" className={classes.large} /></Grid>
                                        <Grid item xs={10}><Typography variant="h5">{doctor?.name}</Typography></Grid>
                                    </Grid>
                                    <List>
                                        <ListItem>
                                            <ListItemIcon>
                                                <InfoIcon color="primary" />
                                            </ListItemIcon>
                                            <ListItemText
                                                primary={doctor?.address}
                                            />
                                        </ListItem>
                                        <ListItem>
                                            <ListItemIcon>
                                                <InfoIcon color="primary" />
                                            </ListItemIcon>
                                            <ListItemText
                                                primary={bookingDate.toLocaleString()}
                                            />
                                        </ListItem>
                                    </List>
                                    <Typography gutterBottom>We've sent a booking confirmation to the email address you provided.</Typography>
                                    <Box fontWeight="fontWeightBold">
                                        <Typography>Didn't recieve an email?</Typography>
                                    </Box>
                                    <Grid item xs={12}>
                                        <Button variant="contained" color="primary">Resend email</Button>
                                    </Grid>
                                </Grid>
                            </Grid>
                        )
                    }
                    {
                        !bookingComplete && (
                            <Grid container spacing={2}>
                                <Grid item md={6} xs={12}>
                                    <Typography variant="h4" gutterBottom>Make a Booking</Typography>
                                    <Typography gutterBottom>Booking with...</Typography>
                                    <Grid container alignItems="center">
                                        <Grid item xs={2}><Avatar alt={doctor?.fullName} src="https://www.fillmurray.com/300/350" className={classes.large} /></Grid>
                                        <Grid item xs={10}><Typography variant="h5">{doctor?.name}</Typography></Grid>
                                    </Grid>
                                    <List>
                                        <ListItem>
                                            <ListItemIcon>
                                                <InfoIcon color="primary" />
                                            </ListItemIcon>
                                            <ListItemText
                                                primary={doctor?.address}
                                            />
                                        </ListItem>
                                        <ListItem>
                                            <ListItemIcon>
                                                <InfoIcon color="primary" />
                                            </ListItemIcon>
                                            <ListItemText
                                                primary={`Rated ${doctor?.rating} on average`}
                                            />
                                        </ListItem>
                                    </List>
                                </Grid>
                                <Grid md={6} xs={12}>
                                    <Typography variant="h4" gutterBottom>Make a Booking</Typography>
                                    <form id="create-booking-form" action="https://localhost:44308/bookings" method="post">
                                        <Grid container spacing={2}>
                                            <Grid item xs={6}>
                                                <TextField
                                                    id="dateTimeOfBooking"
                                                    name="dateTimeOfBooking"
                                                    label="Booking Date and Time"
                                                    type="datetime-local"
                                                    required
                                                    defaultValue={new Date()}
                                                    InputLabelProps={{
                                                        shrink: true,
                                                    }}
                                                    onChange={onChangeDate}
                                                />
                                            </Grid>
                                            <Grid item xs={6}>
                                                <TextField required id="applicantFullName" name="applicantFullName" label="Full Name" placeholder="Enter your full name" value={fullName} onChange={onChangeName}></TextField>
                                            </Grid>
                                            <Grid item xs={6}>
                                                <TextField required id="applicantEmailAddress" name="applicantEmailAddress" label="Email" placeholder="Enter your email" type="email" value={email} onChange={onChangeEmail}></TextField>
                                            </Grid>
                                            <Grid item xs={6}>
                                                <TextField id="nhsNumber" name="nhsNumber" label="NHS Number (Optional)" placeholder="Enter your nhs number" onChange={onChangeNHSNumber}></TextField>
                                            </Grid>
                                            <TextField hidden type="hidden" id="doctorFullName" name="doctorFullName" value={doctor?.name} />
                                            <TextField hidden type="hidden" id="doctorFullName" name="placeId" value={doctor?.place_id} />
                                            <TextField hidden type="hidden" id="doctorFullName" name="doctorAddress" value={doctor?.address} />
                                        </Grid>

                                    </form>
                                </Grid>
                            </Grid>
                        )
                    }

                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClose} color={bookingComplete ? "primary" : "secondary"}>
                        {!bookingComplete ? "Cancel" : "Close"}
                    </Button>
                    {!bookingComplete && (
                        <Button onClick={handleSubmit} color="primary" variant="contained">
                            Submit
                        </Button>
                    )}

                </DialogActions>
            </Dialog>
        </div>
    );
};

export default BookingFormDialog;
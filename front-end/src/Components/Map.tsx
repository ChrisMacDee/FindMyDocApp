import React, { useEffect, useState } from 'react';
import GoogleMapReact from 'google-map-react';
import DocMarker from './DocMarker';
import { CircularProgress, makeStyles } from '@material-ui/core';
import Marker from './Marker';
import InfoWindow from './InfoWindow';
import BookingFormDialog from './BookingFormDialog';

const useStyles = makeStyles({
    loadIcon: {
        position: "absolute",
        margin: "auto",
        top: 0,
        left: 0,
        bottom: 0,
        right: 0,
    }
});
interface Doctor {
    name: string;
    address: string;
    place_id: string;
    rating: string;
    lat: number;
    lng: number;
}

const Map = (props: any) => {
    const [center, setCenter] = useState({ lat: 0, lng: 0 });
    const [zoom, setZoom] = useState(13);
    const [mapLoaded, setMapLoaded] = useState(false);
    const [map, setMap] = useState(null);
    const [gotUserPosition, setGotUserPosition] = useState(false);
    
    const defaultDocs : Doctor[] = [];
    const [nearbyDocs, setNearbyDocs] = useState(defaultDocs);
    const apiKey: string = 'AIzaSyCl1ESygShXaymDe1xgQ-d3ZH0cqO81yqg';
    const styles = useStyles();

    //Info window state
    const [selectedDoctor, selectDoctor] = useState(null);
    const [showInfoWindow, setInfoWindowShow] = useState(false);
    const [activeMarker, setActiveMarker] = useState(null);


    //Booking form state
    const [open, setOpen] = useState(false);

    const handleApiLoaded = (map: any, maps: any) => {
        setMap(map);
        // Get all nearby docs
        getNearbyDocs(map);
    };

    const handleSuccessGetPosition = (position: GeolocationPosition) => {
        setGotUserPosition(true);
        setCenter({ lat: position.coords.latitude, lng: position.coords.longitude });
        setMapLoaded(true);
    }
    const callback = (results: any, status: any) => {
        let doctors: Doctor[] = [];

        if (status == google.maps.places.PlacesServiceStatus.OK) {
            for (var i = 0; i < results.length; i++) {
                var place = results[i];
                doctors.push(
                    {
                        name: place.name,
                        address: place.formatted_address,
                        place_id: place.place_id,
                        rating: place.rating,
                        lat: place.geometry.location.lat(),
                        lng: place.geometry.location.lng(),
                    }
                )
            }
        }
        setNearbyDocs(doctors);
    }

    const request = {
        location: center,
        radius: 10000,
        type: 'doctor',
        query:'Dr'
    };

    const getNearbyDocs = (theMap: any) => {
        const service = new google.maps.places.PlacesService(theMap as unknown as HTMLDivElement);
        service.textSearch(request, callback);
    };

    useEffect(() => {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(
                handleSuccessGetPosition,
                () => {
                    console.log('Could not get user position. Defaulting to London');
                    setCenter({ lat: 51.5074, lng: -0.1278 });
                    setMapLoaded(true);
                },
                {
                    enableHighAccuracy: true,
                    timeout: 5000,
                    maximumAge: 0
                }
            )
        }
    }, [])

    // Info window events
    const onMarkerClick = (key: any, props: any) => {
        selectDoctor(props);
        nearbyDocs.forEach(item => {
            if(item.place_id == key) {
                setActiveMarker(props.doctor);
                (map as unknown as google.maps.Map)?.panTo({lat: props.lat, lng: props.lng})
                handleClickOpen();
            }
        });
        setInfoWindowShow(true);
    }

    const onMapClick = (props: any) => {
        if(showInfoWindow) {
            setInfoWindowShow(false);
            setActiveMarker(null);
        }
    }

    // Booking dialog show
    const handleClickOpen = () => {
        setOpen(true);
      };
    
      const handleClose = () => {
        setOpen(false);
      };

    return (
        <div style={{ height: '100vh', width: '100%' }}>
            {!mapLoaded && (
                <CircularProgress className={styles.loadIcon} />
            )}

            {mapLoaded && (
                <GoogleMapReact
                    bootstrapURLKeys={{
                        key: apiKey,
                        libraries: ['places']
                    }}
                    defaultCenter={center}
                    defaultZoom={zoom}
                    yesIWantToUseGoogleMapApiInternals
                    onGoogleApiLoaded={({ map, maps }) => handleApiLoaded(map, maps)}
                    onClick={onMapClick}
                    onChildClick={onMarkerClick}
                >
                    {/* User position */}
                    {gotUserPosition && (
                        <Marker
                            lat={center.lat}
                            lng={center.lng}
                            text="Glasgow"
                        />
                    )}

                    {/* Render each doctor location */}
                    {
                        nearbyDocs && nearbyDocs.length > 0 && nearbyDocs.map((item, index) => {
                            return (
                                <DocMarker key={item.place_id}
                                lat={item.lat}
                                lng={item.lng}
                                text="Glasgow"
                                doctor={item}
                            /> 
                            )
                        })
                    }                    
                 <BookingFormDialog open={open} handleClose={handleClose} doctor={activeMarker}/>
                </GoogleMapReact>                
            )}
        </div>
    );
}

export default Map;
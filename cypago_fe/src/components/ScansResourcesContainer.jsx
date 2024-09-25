import React, { useState} from 'react';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import Resources from './Resources';
import Scans from './scans'; 
import Typography from '@mui/material/Typography';

function ScansResourcesContainer() {
    const [currentScanId, setScanId] = useState(null);
    const scanRowClick = function (rowId) {
        setScanId(rowId);
    }

    return (
        <Box sx={{ m: 4 }}>
            <Typography variant="h4" component="h4" sx={{ m: 5}} >
                Scans and Resources
            </Typography>
            <Grid container sx={{ m: 5 }} spacing={2} wrap='nowrap' sx={{ width: '100%' }}>
                <Grid sx={{ width: '35%' }}>
                    <Scans scanRowClickHandler={scanRowClick}></Scans>
                </Grid>
                <Grid sx={{ width: '65%' }}>
                    <Resources scanid={currentScanId}></Resources>
                </Grid>
            </Grid>
        </Box>
    );
}

export default ScansResourcesContainer;

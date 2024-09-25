import React, { useState, useEffect } from 'react';
import Grid from '@mui/material/Grid';
import Resources from './Resources';
import Scans from './scans'; 
import Typography from '@mui/material/Typography';

function ScansResourcesContainer() {
    const [currentScanId, setScanId] = useState(null);
    const scanRowClick = function (rowId) {
        setScanId(rowId);
    }

    return (
        <div>
            <Typography variant="h3" component="h3">
                Scans and Resources
            </Typography>
            <Grid container spacing={1} wrap='nowrap'>
                <Grid size={3}>
                    <Scans scanRowClickHandler={scanRowClick}></Scans>
                </Grid>
                <Grid size={9}>
                    <Resources scanid={currentScanId}></Resources>
                </Grid>
            </Grid>
        </div>
    );
}

export default ScansResourcesContainer;

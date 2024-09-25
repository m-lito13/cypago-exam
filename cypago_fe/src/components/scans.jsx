import React, { useState, useEffect } from 'react';
import Grid  from '@mui/material/Grid';
import { DataGrid } from '@mui/x-data-grid';
import { getAllScans }  from '../services/DataService';
import Resources from './Resources';

function Scans() {
    const [dataFromAPI, setDataFromApi] = useState([]);
    const [currentScanId, setScanId] = useState(null);
    useEffect(() => {
        getAllScans().then((res) => setDataFromApi(res)); 
        
    }, []);


    let rows = dataFromAPI;
    let columns = [
        { field: 'startTime', headerName: 'Start' },
        { field: 'endTime', headerName: 'Finish' }
    ];

    const  handleRowClick = function(rowId) { 
        setScanId(rowId);
    }

    return (
        <div>
            <Grid container spacing={1} wrap='nowrap'>
                <Grid size={4}>
                    <DataGrid
                        autosizeOptions={{
                            columns: ['startTime', 'endTime'],
                            includeOutliers: true,
                            includeHeaders: false,
                        }}
                        rows={rows}
                        columns={columns}
                        initialState={{
                            pagination: {
                                paginationModel: {
                                    pageSize: 10,
                                },
                            },
                        }}
                        pageSizeOptions={[5]}
                        disableRowSelectionOnClick
                        onRowClick={(row) => handleRowClick(row.id)}
                    />
                </Grid>
                <Grid size={8}>
                    <Resources scanid={currentScanId}></Resources>    
                </Grid>
        </Grid>
        </div>
    );
} 

export default Scans;

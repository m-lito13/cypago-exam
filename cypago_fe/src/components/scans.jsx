import React, { useState, useEffect } from 'react';
import Grid  from '@mui/material/Grid';
import { DataGrid } from '@mui/x-data-grid';
import getAllScans from '../services/ScansService';
import Button from '@mui/material/Button';

function Scans() {
    const [dataFromAPI, setDataFromApi] = useState([]);
    useEffect(() => {
        getAllScans().then((res) => setDataFromApi(res)); 
        
    }, []);


    let rows = dataFromAPI;
    let columns = [
        { field: 'startTime', headerName: 'Start', width: 300 },
        { field: 'endTime', headerName: 'Finish', width: 600 }
    ];


    return (
        <div>
            <Grid container spacing={2}>
            <DataGrid
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
                    />
               yes 
                <DataGrid
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
                    />
                
        </Grid>
        </div>
    );
} 

export default Scans;

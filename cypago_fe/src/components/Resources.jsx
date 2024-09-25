import React, { useState, useEffect } from 'react';
import Grid from '@mui/material/Grid';
import { DataGrid } from '@mui/x-data-grid';
import { getResources } from '../services/DataService';

function Resources(props) {
    const [dataFromAPI, setDataFromApi] = useState([]);
    let currentScanId = props.scanid;
    console.log('scanID passed:' + currentScanId);
    useEffect(() => {
        console.log('call redraw');
        getResources(currentScanId).then((res) => setDataFromApi(res));
    }, [props]);

    

    let rows = dataFromAPI;
    let columns = [
        { field: 'urn', headerName: 'URN', width: 300 },
        { field: 'name', headerName: 'Name', width: 600 },
        { field: 'data', headerName: 'Data', width: 300 },
        { field: 'resourceType', headerName: 'Type', width: 600 }
    ];

    for (let i = 0; i < rows.length; i++) { 
        console.log('rows :' + rows[i].urn+' '+rows[i].scanID);
    }

    
    return (
        <div>
            <Grid container spacing={2}>
                <DataGrid
                    rows={rows}
                    columns={columns}
                    initialstate={{
                        pagination: {
                            paginationmodel: {
                                pagesize: 10,
                            },
                        },
                    }}
                    pagesizeoptions={[5]}
                    disablerowselectiononclick
                    getRowId={(row) => row.urn+row.dataHash+row.scanID}
                />
            </Grid>
        </div>
    );
}

export default Resources;

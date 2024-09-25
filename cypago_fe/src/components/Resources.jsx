import React, { useState, useEffect } from 'react';
import Grid from '@mui/material/Grid';
import { DataGrid } from '@mui/x-data-grid';
import { getResources } from '../services/DataService';

function Resources(props) {
    const [dataFromAPI, setDataFromApi] = useState([]);
    let currentScanId = props.scanid;
    useEffect(() => {
        getResources(currentScanId).then((res) => setDataFromApi(res));
    }, [props]);

    

    let rows = dataFromAPI;
    let columns = [
        { field: 'urn', headerName: 'URN', width: 125, minWidth: 150, maxWidth: 300 },
        { field: 'name', headerName: 'Name' },
        { field: 'data', headerName: 'Data' ,width: 125, minWidth: 150, maxWidth: 300 },
        { field: 'resourceType', headerName: 'Type' }
    ];
   
    return (
        <div>
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
                getRowId={(row) => row.urn + row.dataHash + row.scanID}
            />
        </div>
    );
}

export default Resources;

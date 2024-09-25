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
        { field: 'urn', headerName: 'URN', flex: 0.35 },
        { field: 'name', headerName: 'Name', flex: 0.2 },
        { field: 'data', headerName: 'Data', flex: 0.35 },
        { field: 'resourceType', headerName: 'Type', flex: 0.1 }
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

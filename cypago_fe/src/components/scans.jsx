import React, { useState, useEffect } from 'react';
import { DataGrid } from '@mui/x-data-grid';
import { getAllScans }  from '../services/DataService';

function Scans(props) {
    const [dataFromAPI, setDataFromApi] = useState([]);
    useEffect(() => {
        getAllScans().then((res) => setDataFromApi(res)); 
    }, []);


    let rows = dataFromAPI;
    let columns = [
        { field: 'startTime', headerName: 'Start' ,flex :  0.5},
        { field: 'endTime', headerName: 'Finish' , flex : 0.5 }
    ];

    const  handleRowClick = function(rowId) { 
        if (props.scanRowClickHandler) { 
            props.scanRowClickHandler(rowId)
        }
    }

    return (
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
            onRowClick={(row) => handleRowClick(row.id)}
        />
       
    );
} 

export default Scans;

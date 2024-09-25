const BASE_SCANS_URL = "http://localhost:5097/api/scans";
const BASE_RESOURCES_URL = "http://localhost:5097/api/resources";
export async function getAllScans() { 
    let dataFromApi = [];
    try {
        await fetch(BASE_SCANS_URL)
            .then((data) => data.json())
            .then((data) => dataFromApi = data);
    }
    catch (err) { 
        console.log('Cannot fetch data. Error: ' + err);
    }
   
    return dataFromApi;
}
export async function getResources(scanId) { 
    let dataFromApi = [];
    if (scanId != null) { 
        let urlWithScan = `${BASE_RESOURCES_URL}?scanid=${scanId}`;
        try { 
            await fetch(urlWithScan)
                .then((data) => data.json())
                .then((data) => dataFromApi = data);
        }
        catch(err) { 
            console.log('Cannot fetch data. Error: ' + err);
        }
    }
    return dataFromApi;
}

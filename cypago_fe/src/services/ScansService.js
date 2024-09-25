const BASE_URL = "http://localhost:5097/api/scans"
async function getAllScans() { 
    let dataFromApi = [];
    await fetch(BASE_URL)
        .then((data) => data.json())
        .then((data) => dataFromApi = data);
    console.log(dataFromApi);
    return dataFromApi;
}

export default getAllScans;
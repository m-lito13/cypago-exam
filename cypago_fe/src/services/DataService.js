const BASE_SCANS_URL = "http://localhost:5097/api/scans";
const BASE_RESOURCES_URL = "http://localhost:5097/api/resources";
export async function getAllScans() { 
    let dataFromApi = [];
    await fetch(BASE_SCANS_URL)
        .then((data) => data.json())
        .then((data) => dataFromApi = data);
    return dataFromApi;
}
export async function getResources(scanId) { 
    let dataFromApi = [];
    console.log('getResources scanId: ' + scanId);
    let urlWithScan = (scanId != null)
        ? `${BASE_RESOURCES_URL}?scanid=${scanId}`
        : BASE_RESOURCES_URL;
    await fetch(urlWithScan)
        .then((data) => data.json())
        .then((data) => dataFromApi = data);
    return dataFromApi;
}

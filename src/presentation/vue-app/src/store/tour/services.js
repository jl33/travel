import api from "@/api/api-v1-config";
export async function getTourListsAxios(){
    return await api.get("TourLists");
}

export async function deleteTourListAxios(id){
    return await api.delete("TourLists/"+id);
}
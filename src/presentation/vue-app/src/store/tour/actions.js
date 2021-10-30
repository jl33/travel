import * as types from "./types";
import { getTourListsAxios, deleteTourListAxios,postTourListAxios, } from "@/store/tour/services";

export async function getTourListsAction({ commit }) {
  commit(types.LOADING_TOUR, true);
  try {
    const { data } = await getTourListsAxios();
    commit(types.GET_TOUR_LISTS, data.lists);
  } catch (e) {
    alert(e);
    console.log(e);
  }

  commit(types.LOADING_TOUR, false);
}

export async function removeTourListAction({ commit }, payload) {
  commit(types.LOADING_TOUR, true);
  try {
    await deleteTourListAxios(payload);
    commit(types.REMOVE_TOUR_LIST, payload);
  } catch (e) {
    alert(e);
    console.log(e);
  }
  commit(types.LOADING_TOUR, false);
}

export async function addTourListAction({commit},payload){
  commit(types.LOADING_TOUR,true);
  try{
    const {data} =await postTourListAxios(payload);
    payload.id=data;
    payload.tourPackages=[];
    commit(types.ADD_TOUR_LIST,payload);
  }catch(e){
    alert(e);
    console.log(e);
  }
  commit(types.LOADING_TOUR,false);
}
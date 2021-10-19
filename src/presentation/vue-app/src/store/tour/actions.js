import * as types from "./types";
import { getTourListsAxios } from "./services";
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

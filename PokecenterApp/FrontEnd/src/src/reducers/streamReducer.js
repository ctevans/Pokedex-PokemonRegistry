import _ from "lodash";

import {
  SEARCH_PKMN_BY_NAME,
  FETCH_ONE_PKMN
} from "../actions/types";

export default (state = {}, action) => {
  switch (action.type) {
    case SEARCH_PKMN_BY_NAME:
      return { state, ..._.mapKeys(action.payload, "id") };
    case FETCH_ONE_PKMN:
      return { state, [action.payload.id]: action.payload };
    default:
      return state;
  }
};

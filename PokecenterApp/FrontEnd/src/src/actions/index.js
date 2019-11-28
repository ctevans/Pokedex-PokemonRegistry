import pokemonAPI from "../apis/pokemonAPI";
import {
  SEARCH_PKMN_BY_NAME,
  FETCH_ONE_PKMN
} from "./types";

export const searchForPokemonByName = name => async dispatch => {
  const response = await pokemonAPI.get(`pokemon/name=${name}`);
  dispatch({ type: SEARCH_PKMN_BY_NAME, payload: response.data });
};

export const fetchOnePokemon = pokemonId => async dispatch => {
  const response = await pokemonAPI.get(`/pokemon/id=${pokemonId}`);
  dispatch({ type: FETCH_ONE_PKMN, payload: response.data });
};
import { combineReducers } from "redux";
import { reducer as formReducer } from "redux-form";
import streamReducer from './streamReducer';

export default combineReducers({
  pokemon: streamReducer,
});

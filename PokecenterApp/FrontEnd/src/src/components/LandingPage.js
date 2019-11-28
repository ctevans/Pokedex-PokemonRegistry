import React from "react";
import { connect } from "react-redux";
import { Link } from "react-router-dom";
import { fetchOnePokemon, searchForPokemonByName } from "../actions";
import { Input, Image, Container, Grid, Button, Divider } from "semantic-ui-react";

class LandingPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            searchQuery: ""
        }
        this.state.isOnSearchState = false;
        this.state.isOnPokemonFocus = false;
    }

    handleSubmitSearchButtonPress = (input) => {
        this.props.searchForPokemonByName(this.state.searchQuery);
    }

    handleSearchInput = input => {
        this.setState({ searchQuery: input.target.value })
    }

    componentDidMount() {
        document.title = "Cole's Pokedex";
    }

    pokemonNameClicked = (id) => {
        this.props.fetchOnePokemon(id);
    }

    renderList() {
        if (this.props.pokemonList.length < 3) {
            return;
        }
        return this.props.pokemonList.map(pokemon => {
            return (
                <div className="item" key={pokemon.id}>
                    <i className="large middle aligned icon camera" />
                    <div className="content">
                        <Button onClick={() => this.pokemonNameClicked(pokemon.id)} className="header">
                            {pokemon.name}
                        </Button>
                        <div className="description">Trainer ID: {pokemon.trainer_id}</div>
                    </div>
                </div>
            );
        });
    }

    renderPokemonDetails() {
        if (0 == this.props.pokemonList.length || this.props.pokemonList.length > 3) {
            return;
        }
        console.log(this.props.pokemonList[0])

        console.log(this.props.pokemonList.length)

        const focusedPokmemon = this.props.pokemonList[0];

        return (
            <div>
                <h1>
                    {focusedPokmemon.name} Details:
                </h1>
                <div>Base Total Stats: {focusedPokmemon.base_total}</div>
                <div>Experience Growth: {focusedPokmemon.experience_growth}</div>
                <div>Hp: {focusedPokmemon.hp}</div>
                <div>Special Attack: {focusedPokmemon.sp_attack}</div>
                <div>Special Defense: {focusedPokmemon.sp_defense}</div>
                <div>Speed: {focusedPokmemon.speed}</div>
                <div>Type 1: {focusedPokmemon.type1}</div>
                <div>Type 2: {focusedPokmemon.type2}</div>
            </div>
        )
        // return this.props.pokemonList.map(pokemon => {
        //     return (
        //         <div className="item" key={pokemon.id[0]}>
        //             <i className="large middle aligned icon camera" />
        //             <div className="content">
        //                 <Button onClick={() => this.pokemonNameClicked(pokemon.id)} className="header">
        //                     {pokemon.name}
        //                 </Button>
        //                 <div className="description">Trainer ID: {pokemon.trainer_id}</div>
        //             </div>
        //         </div>
        //     );
        // });
    }

    render() {
        const { isOnSearchState } = this.state;
        const { isOnPokemonFocus } = this.state;

        if (isOnSearchState) {
            return (<div>searchstate</div>)
        } else if (isOnPokemonFocus) {
            return (<div>pokefocus</div>)
        } else {
            return (
                <div>
                    <Grid>
                        <Grid.Column>
                            <Grid.Row>
                                <Image
                                    src={require("../images/mainimage.png")}
                                />
                            </Grid.Row>
                            <Grid.Row>
                                <div>
                                    <Input fluid icon='search' placeholder='Search...' onChange={this.handleSearchInput} />
                                    <Container textAlign='center'><Button basic onClick={this.handleSubmitSearchButtonPress.bind(this)}>Submit</Button></Container>
                                </div>
                            </Grid.Row>
                            <div className="ui celled list">{this.renderList()}</div>
                            <div>{this.renderPokemonDetails()}</div>
                        </Grid.Column>
                    </Grid>
                </div>
            );
        }
    }
}

const mapStateToProps = state => {
    console.log(state);
    //Object.values turns all values in an object into an array.
    return {
        pokemonList: Object.values(state.pokemon),
        pokemonOfFocus: state.pokemonOfFocus
    };
};

export default connect(
    mapStateToProps,
    { searchForPokemonByName, fetchOnePokemon }
)(LandingPage);


import playerList from "../../assets/player-list";
const SET_SEARCH = "SET_SEARCH";
const SET_FILTER = "SET_FILTER";
const state = {
    players: playerList,
    search: '',
    filter: {
        key: 'rank',
        order: 'desc'
    }
}

const mutations = {
    [SET_SEARCH](state, search) {
        state.search = search;
    },
    [SET_FILTER](state, filter) {
        state.filter = filter;
    },
}

const actions = {
    search({ commit }, search) {
        commit(SET_SEARCH, search);
    },
    filter({ commit }, filter) {
        commit(SET_FILTER, filter);
    },
}

const getters = {
    getPlayers: state => {
        return state.players.filter(player => player.shortname.toLowerCase().indexOf(state.search.toLowerCase()) > -1)
        .sort(compare(state.filter));
    },
    getPlayerById: state => id => {
        return state.players.find(player => player.id === id)
    }
}
const compare = ({key,order}) => {
    return (a,b) => {
        let result = 0;
        if(a[key] > b[key]){
            result = 1;
        }
        if(a[key] < b[key]){
            result = -1;
        }
        if(order === 'asc') return result;

        return result * -1;
    }
}
export default {
    state,
    mutations,
    actions,
    getters
}
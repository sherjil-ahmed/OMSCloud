import React from 'react';

class SearchSelect extends React.Component {
  constructor(props) {
    super(props);
    this.refInputSearch = React.createRef();

    this.prevIterator = -1;
    this.iterator = -1;
    this.reflist = [];

    this.state = {
      //list : this.props.list,
      searchlist: [],
      search: '',
      showSearchList: false,
    };
  }

  componentDidMount() {
    if (this.props.setSearchInputRef) {
      this.props.setSearchInputRef(this.refInputSearch);
    }
  }

  SearchChange = (e) => {
    if (this.props.hookInputTyping) {
      this.props.hookInputTyping(e);
    }

    this.setState(
      {
        search: e.target.value.toLowerCase(),
      },
      () => {
        let tempList = [];
        if (
          this.state.search != '' &&
          this.state.search.length > this.props.CharacterCount
        ) {
          if (this.props.customSearchHook) {
            tempList = this.props.customSearchHook();
          } else {
            tempList = this.props.list.filter((a) => {
              let cRet = false;
              if (this.props.filter === 'ALL') {
                for (let key in a) {
                  if (
                    a[key] &&
                    typeof a[key] === 'string' &&
                    a[key].toLowerCase().includes(e.target.value.toLowerCase())
                  ) {
                    cRet = true;
                    break;
                  }
                }
              } else {
                for (let key of this.props.filter) {
                  if (a[key] && a[key].toLowerCase().includes(e.target.value)) {
                    cRet = true;
                    break;
                  }
                }
              }
              return cRet;
            });
          }

          this.reflist = [];
          this.iterator = -1;
          this.prevIterator = -1;
          this.setState(
            {
              searchlist: JSON.parse(JSON.stringify(tempList)),
              showSearchList: true,
            },
            () => {},
          );
        } else {
          this.reflist = [];
          this.iterator = -1;
          this.prevIterator = -1;
          this.setState(
            {
              showSearchList: false,
            },
            () => {},
          );
        }
      },
    );
  };

  onItemSelect = (obj) => {
    this.setState({
      showSearchList: false,
      search: '',
    });
    this.props.selectHook(obj, this.props.sKey);
  };

  handleKeyPress = (e) => {
    if (e.key === 'Enter') {
      //assuming iterator is correctly set &
      //most importantly, the [first] child element has onclick implemented
      if (
        this.iterator >= 0 &&
        this.reflist &&
        this.reflist.length > 0 &&
        this.iterator < this.reflist.length
      ) {
        if (this.reflist[this.iterator].current) {
          this.reflist[this.iterator].current.children[0].click();
        }
      }
      //this.reflist[this.iterator].current.children[0].click();
    }
  };

  handleKeyDown = (e) => {
    if (
      this.state.searchlist &&
      this.state.searchlist != null &&
      this.state.searchlist != [] &&
      this.state.searchlist.length > 0
    ) {
      //down arrow
      if (e.keyCode === 40) {
        e.preventDefault();
        if (this.iterator == -1) {
          this.iterator = 0;
        } else if (this.iterator == this.state.searchlist.length - 1) {
          this.reflist[
            this.state.searchlist.length - 1
          ].current.classList.remove('SearchSelectItem-focus');
          this.iterator = 0;
        } else {
          this.reflist[this.iterator].current.classList.remove(
            'SearchSelectItem-focus',
          );
          this.iterator++;
        }
        this.reflist[this.iterator].current.classList.add(
          'SearchSelectItem-focus',
        );
        this.reflist[this.iterator].current.scrollIntoViewIfNeeded();

        //clean up
      }

      if (e.keyCode === 38) {
        e.preventDefault();
        if (this.iterator == -1) {
          this.iterator = this.state.searchlist.length - 1;
        } else if (this.iterator == 0) {
          this.reflist[0].current.classList.remove('SearchSelectItem-focus');
          this.iterator = this.state.searchlist.length - 1;
        } else {
          this.reflist[this.iterator].current.classList.remove(
            'SearchSelectItem-focus',
          );
          this.iterator--;
        }
        this.reflist[this.iterator].current.classList.add(
          'SearchSelectItem-focus',
        );
        this.reflist[this.iterator].current.scrollIntoViewIfNeeded();
      }
    }
  };

  render() {
    return (
      <div style={{ position: 'relative', width: '100%' }}>
        {this.props.autoFocus && this.props.autoFocus != '' ? (
          this.props.autoFocus == 'false' ? (
            <input
              ref={this.refInputSearch}
              type="text"
              className="form-control"
              placeholder={this.props.placeholder}
              onChange={this.SearchChange}
              value={this.state.search}
              onKeyDown={this.handleKeyDown}
              onKeyPress={this.handleKeyPress}
              disabled={this.props.disabled}
            />
          ) : (
            <input
              ref={this.refInputSearch}
              autoFocus
              type="text"
              className="form-control"
              placeholder={this.props.placeholder}
              onChange={this.SearchChange}
              value={this.state.search}
              onKeyDown={this.handleKeyDown}
              onKeyPress={this.handleKeyPress}
              disabled={this.props.disabled}
            />
          )
        ) : (
          <input
            ref={this.refInputSearch}
            autoFocus
            type="text"
            className="form-control"
            placeholder={this.props.placeholder}
            onChange={this.SearchChange}
            value={this.state.search}
            onKeyDown={this.handleKeyDown}
            onKeyPress={this.handleKeyPress}
            disabled={this.props.disabled}
          />
        )}
        {this.state.showSearchList ? (
          <div
            style={{
              position: 'absolute',
              maxHeight: '200px',
              overflowY: 'scroll',
              zIndex: 5,
              background: 'white',
              top: '35px',
              width: 'inherit',
              borderStyle: 'groove',
            }}
          >
            {this.state.searchlist &&
            this.state.searchlist != null &&
            this.state.searchlist != [] &&
            this.state.searchlist.length > 0 ? (
              this.state.searchlist.map((obj, i) => {
                let tempRef = React.createRef();
                this.reflist.push(tempRef);
                return (
                  <div ref={tempRef} className="SearchSelectItem" key={i}>
                    {this.props.displayHook(obj, i, this.onItemSelect)}
                  </div>
                );
              })
            ) : (
              <div>No result found</div>
            )}
          </div>
        ) : (
          <div></div>
        )}
      </div>
    );
  }
}

export default SearchSelect;

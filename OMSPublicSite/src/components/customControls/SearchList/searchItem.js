import React from 'react';

class SearchItem extends React.Component {
  constructor(props) {
    super(props);
  }
  searchTypedKeyword = (e) => {
    let completeData = this.props.parentData;
    let newList = completeData.filter((a) => {
      for (let prop of this.props.criteria) {
        if (
          a[prop] &&
          a[prop]
            .toString()
            .toLowerCase()
            .includes(e.target.value.toLowerCase())
        ) {
          return a;
        }
      }
    });
    this.props.updateList(newList);
  };
  render() {
    return (
      <div class="search-wrapper">
        <form>
          <input
            ref={(input) => {
              this.searchInput = input;
            }}
            autoComplete="off"
            type="text"
            name="focus"
            class="search-box"
            placeholder="Search..."
            onChange={this.searchTypedKeyword}
          />
          <label
            class="close-icon"
            onClick={(e) => {
              e.preventDefault();
              this.searchInput.value = '';
              this.searchTypedKeyword({ target: { value: '' } });
              this.props.updateList(this.props.parentData);
            }}
          ></label>
        </form>
      </div>
    );
  }
}
export default SearchItem;

// A '.tsx' file enables JSX support in the TypeScript compiler, 
// for more information see the following page on the TypeScript wiki:
// https://github.com/Microsoft/TypeScript/wiki/JSX
var CommentBox = React.createClass({
    render: function () {
        return (React.createElement("div", {"className": "commentBox"}, "Hello, world!I am a CommentBox."));
    }
});
ReactDOM.render(React.createElement(CommentBox, null), document.getElementById('content'));

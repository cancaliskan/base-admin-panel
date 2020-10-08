$(document).on({
    click: function () {
        $('body').toggleClass('fcd-ie8'); //For the stupid ie8
        $(this).toggleClass('open');
        return false;
    }
}, ".cbxTree-swicth");
$(document).on({
    change: function () {
        var $node = $(this).closest('.cbxTree-node');
        if ($(this).is(':checked')) {
            $node.children('.cbxTree-swicth').addClass('open');
        }
        $node.find('.cbxTree-cbx').prop({ checked: $(this).is(':checked') });
    }
}, ".cbxTree-cbx");

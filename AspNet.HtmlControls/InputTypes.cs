namespace AspNet.HtmlControls
{
    public enum InputTypes
    {
        Button, //	定义可点击按钮（多数情况下，用于通过 JavaScript 启动脚本）。
        Checkbox, //	定义复选框。
        File, //	定义输入字段和 "浏览"按钮，供文件上传。
        Hidden, //	定义隐藏的输入字段。
        Image, //	定义图像形式的提交按钮。
        Password, //	定义密码字段。该字段中的字符被掩码。
        Radio, //	定义单选按钮。
        Reset, //	定义重置按钮。重置按钮会清除表单中的所有数据。
        Submit, //	定义提交按钮。提交按钮会把表单数据发送到服务器。
        Text, // 定义单行的输入字段，用户可在其中输入文本。默认宽度为 20 个字符。
        Date,
        Datetime,
        LocalDateTime,
        Email,
        Month,
        Number,
        Range,
        Time,
        Url,
        Week,
        Invalid,
    }
}

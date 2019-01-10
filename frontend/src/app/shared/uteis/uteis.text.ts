
export class UteisText {

    static isNullOrEmpty(text: string): boolean {

        var result = false;

        if (text == null)
            result = true;

        else if (text == "")
            result = true;

        else if (text == undefined)
            result = true;

        return result;
    }

    static concatenate(text: string[]): string {

        var result = "";

        text.forEach(element => {
            result += element;
        });

        return result;
    }

    static concatenateUrl(...text: any[]): any {
        
                var result = "";
        
                text.forEach(element => {
                    result += element + "/";
                });
        
                return result;
            }

    static concatenate2(...text: any[]): any {

        var result = "";

        text.forEach(element => {
            result += element;
        });

        return result;
    }
}
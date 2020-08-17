package com.ankamagames.dofus.network.types.game.character
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class AbstractCharacterInformation implements INetworkType
   {
      
      public static const protocolId:uint = 400;
       
      
      public var id:Number = 0;
      
      public function AbstractCharacterInformation()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 400;
      }
      
      public function initAbstractCharacterInformation(param1:Number = 0) : AbstractCharacterInformation
      {
         this.id = param1;
         return this;
      }
      
      public function reset() : void
      {
         this.id = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_AbstractCharacterInformation(param1);
      }
      
      public function serializeAs_AbstractCharacterInformation(param1:ICustomDataOutput) : void
      {
         if(this.id < 0 || this.id > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.id + ") on element id.");
         }
         param1.writeVarLong(this.id);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AbstractCharacterInformation(param1);
      }
      
      public function deserializeAs_AbstractCharacterInformation(param1:ICustomDataInput) : void
      {
         this._idFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AbstractCharacterInformation(param1);
      }
      
      public function deserializeAsyncAs_AbstractCharacterInformation(param1:FuncTree) : void
      {
         param1.addChild(this._idFunc);
      }
      
      private function _idFunc(param1:ICustomDataInput) : void
      {
         this.id = param1.readVarUhLong();
         if(this.id < 0 || this.id > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.id + ") on element of AbstractCharacterInformation.id.");
         }
      }
   }
}

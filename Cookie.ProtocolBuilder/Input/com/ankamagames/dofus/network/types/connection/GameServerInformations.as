package com.ankamagames.dofus.network.types.connection
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class GameServerInformations implements INetworkType
   {
      
      public static const protocolId:uint = 25;
       
      
      public var id:uint = 0;
      
      public var type:int = -1;
      
      public var status:uint = 1;
      
      public var completion:uint = 0;
      
      public var isSelectable:Boolean = false;
      
      public var charactersCount:uint = 0;
      
      public var charactersSlots:uint = 0;
      
      public var date:Number = 0;
      
      public function GameServerInformations()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 25;
      }
      
      public function initGameServerInformations(param1:uint = 0, param2:int = -1, param3:uint = 1, param4:uint = 0, param5:Boolean = false, param6:uint = 0, param7:uint = 0, param8:Number = 0) : GameServerInformations
      {
         this.id = param1;
         this.type = param2;
         this.status = param3;
         this.completion = param4;
         this.isSelectable = param5;
         this.charactersCount = param6;
         this.charactersSlots = param7;
         this.date = param8;
         return this;
      }
      
      public function reset() : void
      {
         this.id = 0;
         this.type = -1;
         this.status = 1;
         this.completion = 0;
         this.isSelectable = false;
         this.charactersCount = 0;
         this.charactersSlots = 0;
         this.date = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameServerInformations(param1);
      }
      
      public function serializeAs_GameServerInformations(param1:ICustomDataOutput) : void
      {
         if(this.id < 0)
         {
            throw new Error("Forbidden value (" + this.id + ") on element id.");
         }
         param1.writeVarShort(this.id);
         param1.writeByte(this.type);
         param1.writeByte(this.status);
         param1.writeByte(this.completion);
         param1.writeBoolean(this.isSelectable);
         if(this.charactersCount < 0)
         {
            throw new Error("Forbidden value (" + this.charactersCount + ") on element charactersCount.");
         }
         param1.writeByte(this.charactersCount);
         if(this.charactersSlots < 0)
         {
            throw new Error("Forbidden value (" + this.charactersSlots + ") on element charactersSlots.");
         }
         param1.writeByte(this.charactersSlots);
         if(this.date < -9007199254740990 || this.date > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.date + ") on element date.");
         }
         param1.writeDouble(this.date);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameServerInformations(param1);
      }
      
      public function deserializeAs_GameServerInformations(param1:ICustomDataInput) : void
      {
         this._idFunc(param1);
         this._typeFunc(param1);
         this._statusFunc(param1);
         this._completionFunc(param1);
         this._isSelectableFunc(param1);
         this._charactersCountFunc(param1);
         this._charactersSlotsFunc(param1);
         this._dateFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameServerInformations(param1);
      }
      
      public function deserializeAsyncAs_GameServerInformations(param1:FuncTree) : void
      {
         param1.addChild(this._idFunc);
         param1.addChild(this._typeFunc);
         param1.addChild(this._statusFunc);
         param1.addChild(this._completionFunc);
         param1.addChild(this._isSelectableFunc);
         param1.addChild(this._charactersCountFunc);
         param1.addChild(this._charactersSlotsFunc);
         param1.addChild(this._dateFunc);
      }
      
      private function _idFunc(param1:ICustomDataInput) : void
      {
         this.id = param1.readVarUhShort();
         if(this.id < 0)
         {
            throw new Error("Forbidden value (" + this.id + ") on element of GameServerInformations.id.");
         }
      }
      
      private function _typeFunc(param1:ICustomDataInput) : void
      {
         this.type = param1.readByte();
      }
      
      private function _statusFunc(param1:ICustomDataInput) : void
      {
         this.status = param1.readByte();
         if(this.status < 0)
         {
            throw new Error("Forbidden value (" + this.status + ") on element of GameServerInformations.status.");
         }
      }
      
      private function _completionFunc(param1:ICustomDataInput) : void
      {
         this.completion = param1.readByte();
         if(this.completion < 0)
         {
            throw new Error("Forbidden value (" + this.completion + ") on element of GameServerInformations.completion.");
         }
      }
      
      private function _isSelectableFunc(param1:ICustomDataInput) : void
      {
         this.isSelectable = param1.readBoolean();
      }
      
      private function _charactersCountFunc(param1:ICustomDataInput) : void
      {
         this.charactersCount = param1.readByte();
         if(this.charactersCount < 0)
         {
            throw new Error("Forbidden value (" + this.charactersCount + ") on element of GameServerInformations.charactersCount.");
         }
      }
      
      private function _charactersSlotsFunc(param1:ICustomDataInput) : void
      {
         this.charactersSlots = param1.readByte();
         if(this.charactersSlots < 0)
         {
            throw new Error("Forbidden value (" + this.charactersSlots + ") on element of GameServerInformations.charactersSlots.");
         }
      }
      
      private function _dateFunc(param1:ICustomDataInput) : void
      {
         this.date = param1.readDouble();
         if(this.date < -9007199254740990 || this.date > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.date + ") on element of GameServerInformations.date.");
         }
      }
   }
}

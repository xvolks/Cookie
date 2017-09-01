package com.ankamagames.dofus.network.messages.game.context.roleplay.death
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameRolePlayPlayerLifeStatusMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5996;
       
      
      private var _isInitialized:Boolean = false;
      
      public var state:uint = 0;
      
      public var phenixMapId:uint = 0;
      
      public function GameRolePlayPlayerLifeStatusMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5996;
      }
      
      public function initGameRolePlayPlayerLifeStatusMessage(param1:uint = 0, param2:uint = 0) : GameRolePlayPlayerLifeStatusMessage
      {
         this.state = param1;
         this.phenixMapId = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.state = 0;
         this.phenixMapId = 0;
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameRolePlayPlayerLifeStatusMessage(param1);
      }
      
      public function serializeAs_GameRolePlayPlayerLifeStatusMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.state);
         if(this.phenixMapId < 0)
         {
            throw new Error("Forbidden value (" + this.phenixMapId + ") on element phenixMapId.");
         }
         param1.writeInt(this.phenixMapId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayPlayerLifeStatusMessage(param1);
      }
      
      public function deserializeAs_GameRolePlayPlayerLifeStatusMessage(param1:ICustomDataInput) : void
      {
         this._stateFunc(param1);
         this._phenixMapIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayPlayerLifeStatusMessage(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayPlayerLifeStatusMessage(param1:FuncTree) : void
      {
         param1.addChild(this._stateFunc);
         param1.addChild(this._phenixMapIdFunc);
      }
      
      private function _stateFunc(param1:ICustomDataInput) : void
      {
         this.state = param1.readByte();
         if(this.state < 0)
         {
            throw new Error("Forbidden value (" + this.state + ") on element of GameRolePlayPlayerLifeStatusMessage.state.");
         }
      }
      
      private function _phenixMapIdFunc(param1:ICustomDataInput) : void
      {
         this.phenixMapId = param1.readInt();
         if(this.phenixMapId < 0)
         {
            throw new Error("Forbidden value (" + this.phenixMapId + ") on element of GameRolePlayPlayerLifeStatusMessage.phenixMapId.");
         }
      }
   }
}

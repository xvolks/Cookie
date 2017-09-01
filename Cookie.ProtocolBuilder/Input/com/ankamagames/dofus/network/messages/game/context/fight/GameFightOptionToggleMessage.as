package com.ankamagames.dofus.network.messages.game.context.fight
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameFightOptionToggleMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 707;
       
      
      private var _isInitialized:Boolean = false;
      
      public var option:uint = 3;
      
      public function GameFightOptionToggleMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 707;
      }
      
      public function initGameFightOptionToggleMessage(param1:uint = 3) : GameFightOptionToggleMessage
      {
         this.option = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.option = 3;
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
         this.serializeAs_GameFightOptionToggleMessage(param1);
      }
      
      public function serializeAs_GameFightOptionToggleMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.option);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightOptionToggleMessage(param1);
      }
      
      public function deserializeAs_GameFightOptionToggleMessage(param1:ICustomDataInput) : void
      {
         this._optionFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightOptionToggleMessage(param1);
      }
      
      public function deserializeAsyncAs_GameFightOptionToggleMessage(param1:FuncTree) : void
      {
         param1.addChild(this._optionFunc);
      }
      
      private function _optionFunc(param1:ICustomDataInput) : void
      {
         this.option = param1.readByte();
         if(this.option < 0)
         {
            throw new Error("Forbidden value (" + this.option + ") on element of GameFightOptionToggleMessage.option.");
         }
      }
   }
}

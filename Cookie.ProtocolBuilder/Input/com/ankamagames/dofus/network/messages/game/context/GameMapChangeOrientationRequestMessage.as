package com.ankamagames.dofus.network.messages.game.context
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameMapChangeOrientationRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 945;
       
      
      private var _isInitialized:Boolean = false;
      
      public var direction:uint = 1;
      
      public function GameMapChangeOrientationRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 945;
      }
      
      public function initGameMapChangeOrientationRequestMessage(param1:uint = 1) : GameMapChangeOrientationRequestMessage
      {
         this.direction = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.direction = 1;
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
         this.serializeAs_GameMapChangeOrientationRequestMessage(param1);
      }
      
      public function serializeAs_GameMapChangeOrientationRequestMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.direction);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameMapChangeOrientationRequestMessage(param1);
      }
      
      public function deserializeAs_GameMapChangeOrientationRequestMessage(param1:ICustomDataInput) : void
      {
         this._directionFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameMapChangeOrientationRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_GameMapChangeOrientationRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._directionFunc);
      }
      
      private function _directionFunc(param1:ICustomDataInput) : void
      {
         this.direction = param1.readByte();
         if(this.direction < 0)
         {
            throw new Error("Forbidden value (" + this.direction + ") on element of GameMapChangeOrientationRequestMessage.direction.");
         }
      }
   }
}

package com.ankamagames.dofus.network.messages.game.context
{
   import com.ankamagames.dofus.network.types.game.context.ActorOrientation;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameMapChangeOrientationMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 946;
       
      
      private var _isInitialized:Boolean = false;
      
      public var orientation:ActorOrientation;
      
      private var _orientationtree:FuncTree;
      
      public function GameMapChangeOrientationMessage()
      {
         this.orientation = new ActorOrientation();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 946;
      }
      
      public function initGameMapChangeOrientationMessage(param1:ActorOrientation = null) : GameMapChangeOrientationMessage
      {
         this.orientation = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.orientation = new ActorOrientation();
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
         this.serializeAs_GameMapChangeOrientationMessage(param1);
      }
      
      public function serializeAs_GameMapChangeOrientationMessage(param1:ICustomDataOutput) : void
      {
         this.orientation.serializeAs_ActorOrientation(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameMapChangeOrientationMessage(param1);
      }
      
      public function deserializeAs_GameMapChangeOrientationMessage(param1:ICustomDataInput) : void
      {
         this.orientation = new ActorOrientation();
         this.orientation.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameMapChangeOrientationMessage(param1);
      }
      
      public function deserializeAsyncAs_GameMapChangeOrientationMessage(param1:FuncTree) : void
      {
         this._orientationtree = param1.addChild(this._orientationtreeFunc);
      }
      
      private function _orientationtreeFunc(param1:ICustomDataInput) : void
      {
         this.orientation = new ActorOrientation();
         this.orientation.deserializeAsync(this._orientationtree);
      }
   }
}

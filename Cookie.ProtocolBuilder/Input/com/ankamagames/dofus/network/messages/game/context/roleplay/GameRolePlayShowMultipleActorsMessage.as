package com.ankamagames.dofus.network.messages.game.context.roleplay
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.context.roleplay.GameRolePlayActorInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameRolePlayShowMultipleActorsMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6712;
       
      
      private var _isInitialized:Boolean = false;
      
      public var informationsList:Vector.<GameRolePlayActorInformations>;
      
      private var _informationsListtree:FuncTree;
      
      public function GameRolePlayShowMultipleActorsMessage()
      {
         this.informationsList = new Vector.<GameRolePlayActorInformations>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6712;
      }
      
      public function initGameRolePlayShowMultipleActorsMessage(param1:Vector.<GameRolePlayActorInformations> = null) : GameRolePlayShowMultipleActorsMessage
      {
         this.informationsList = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.informationsList = new Vector.<GameRolePlayActorInformations>();
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
         this.serializeAs_GameRolePlayShowMultipleActorsMessage(param1);
      }
      
      public function serializeAs_GameRolePlayShowMultipleActorsMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.informationsList.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.informationsList.length)
         {
            param1.writeShort((this.informationsList[_loc2_] as GameRolePlayActorInformations).getTypeId());
            (this.informationsList[_loc2_] as GameRolePlayActorInformations).serialize(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayShowMultipleActorsMessage(param1);
      }
      
      public function deserializeAs_GameRolePlayShowMultipleActorsMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc5_:GameRolePlayActorInformations = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readUnsignedShort();
            _loc5_ = ProtocolTypeManager.getInstance(GameRolePlayActorInformations,_loc4_);
            _loc5_.deserialize(param1);
            this.informationsList.push(_loc5_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayShowMultipleActorsMessage(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayShowMultipleActorsMessage(param1:FuncTree) : void
      {
         this._informationsListtree = param1.addChild(this._informationsListtreeFunc);
      }
      
      private function _informationsListtreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._informationsListtree.addChild(this._informationsListFunc);
            _loc3_++;
         }
      }
      
      private function _informationsListFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:GameRolePlayActorInformations = ProtocolTypeManager.getInstance(GameRolePlayActorInformations,_loc2_);
         _loc3_.deserialize(param1);
         this.informationsList.push(_loc3_);
      }
   }
}

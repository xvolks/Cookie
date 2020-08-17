package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.dofus.network.types.game.look.IndexedEntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class HumanOptionFollowers extends HumanOption implements INetworkType
   {
      
      public static const protocolId:uint = 410;
       
      
      public var followingCharactersLook:Vector.<IndexedEntityLook>;
      
      private var _followingCharactersLooktree:FuncTree;
      
      public function HumanOptionFollowers()
      {
         this.followingCharactersLook = new Vector.<IndexedEntityLook>();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 410;
      }
      
      public function initHumanOptionFollowers(param1:Vector.<IndexedEntityLook> = null) : HumanOptionFollowers
      {
         this.followingCharactersLook = param1;
         return this;
      }
      
      override public function reset() : void
      {
         this.followingCharactersLook = new Vector.<IndexedEntityLook>();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_HumanOptionFollowers(param1);
      }
      
      public function serializeAs_HumanOptionFollowers(param1:ICustomDataOutput) : void
      {
         super.serializeAs_HumanOption(param1);
         param1.writeShort(this.followingCharactersLook.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.followingCharactersLook.length)
         {
            (this.followingCharactersLook[_loc2_] as IndexedEntityLook).serializeAs_IndexedEntityLook(param1);
            _loc2_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HumanOptionFollowers(param1);
      }
      
      public function deserializeAs_HumanOptionFollowers(param1:ICustomDataInput) : void
      {
         var _loc4_:IndexedEntityLook = null;
         super.deserialize(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new IndexedEntityLook();
            _loc4_.deserialize(param1);
            this.followingCharactersLook.push(_loc4_);
            _loc3_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HumanOptionFollowers(param1);
      }
      
      public function deserializeAsyncAs_HumanOptionFollowers(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._followingCharactersLooktree = param1.addChild(this._followingCharactersLooktreeFunc);
      }
      
      private function _followingCharactersLooktreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._followingCharactersLooktree.addChild(this._followingCharactersLookFunc);
            _loc3_++;
         }
      }
      
      private function _followingCharactersLookFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:IndexedEntityLook = new IndexedEntityLook();
         _loc2_.deserialize(param1);
         this.followingCharactersLook.push(_loc2_);
      }
   }
}
